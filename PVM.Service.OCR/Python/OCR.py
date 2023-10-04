from pathlib import Path
import pandas as pd
import numpy as np
import pytesseract
import logging
import easyocr
import utils
import cv2
import os
import re


# Preprocesamiento para imagen // Misma salida, imagen recortada pxcut pixeles
def preprocessed_1(img):
    pxcut = 5
    adaptative_threshold = img
    # Recortar imagen[fila_inicial:fila_final, columna_inicial:columna_final]
    # // pxcut = nºde píxeles a recortar de los bordes
    return adaptative_threshold[pxcut:len(img) - pxcut, pxcut:len(img[0]) - pxcut]


# Preprocesamiento para imagen // Redimensionada, blanco y negro, aumentada nitidez
def preprocessed_2(img):
    img = cv2.resize(img, None, fx=0.9, fy=0.9)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    adaptative_threshold = cv2.adaptiveThreshold(gray, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 185,
                                                 19)  # 85, 35 // 185, 18 // 121, 19 // 11, 2
    pxcut = 40
    # Recortar imagen[fila_inicial:fila_final, columna_inicial:columna_final]
    # // pxcut = nºde píxeles a recortar de los bordes
    return adaptative_threshold[pxcut:len(img) - pxcut, pxcut:len(img[0]) - pxcut]


# Preprocesamiento para imagen // Blanco y negro, Representar imagen con únicamente 2 colores
def preprocessed_3(img):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    adaptative_threshold = cv2.adaptiveThreshold(gray, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 11,
                                                 2)
    pxcut = 20
    # Recortar imagen[fila_inicial:fila_final, columna_inicial:columna_final]
    # // pxcut = nºde píxeles a recortar de los bordes
    return adaptative_threshold[pxcut:len(img) - pxcut, pxcut:len(img[0]) - pxcut]


# Función principal que inicia el procesado de las imágenes a texto
def ocr_processing(path):
    # cargar imágenes
    img_dir = path + r'\images'
    images, img_names = utils.load_images_from_folder(img_dir)
    # Recorre todas las imágenes de la carpeta
    for i in range(len(images)):
        img = cv2.cvtColor(np.array(images[i]), cv2.COLOR_RGB2BGR)
        # preprocesado de imágenes
        img1 = preprocessed_1(img)
        img2 = preprocessed_2(img)
        img3 = preprocessed_3(img)

        # Lineas para ver imagen pre-procesada
        #cv2.imwrite((img_dir + r'\\' + Path(img_names[i]).stem + '_2.jpg'), img2)
        #cv2.imwrite((img_dir + r'\\' + Path(img_names[i]).stem + '_3.jpg'), img3)

        # Aplicar OCR a cada uno de los 3 procesados
        img_texts = []
        txt1 = transcription(img1, 3, 3)
        img_texts.append(txt1)

        txt2 = transcription(img2, 3, 3)
        img_texts.append(txt2)

        txt3 = transcription(img3, 3, 3)
        img_texts.append(txt3)

        utils.text_save(text_comparator(img_texts), os.path.splitext(img_names[i])[0], path)

    # Una vez analizadas las imágenes se borran para optimizar memoria
    print(utils.dispose_images(img_dir))


# Función de procesado de imágenes a texto
def transcription(img, oem, psm):
    # -oem: Specify OCR Engine mode // 3 = Default, based on what is available.
    # -psm: Set Tesseract to only run a subset of layout analysis and assume a certain form of image
    #    // 3 = Fully automatic page segmentation, but no OSD. (Default)
    custom_config = rf'--oem {oem} --psm {psm}'
    text = pytesseract.image_to_string(img, lang='spa', config=custom_config)
    return text


# Función que saca orientación e información util analizando la imagen
def osd(img):
    data = pytesseract.image_to_osd(img, output_type=pytesseract.Output.DICT)
    return data


# Compara strings de texto devolviendo el de mayor fiabilidad
def text_comparator(texts):
    try:
        if texts[0] == texts[1] or texts[0] == texts[2]:
            text = texts[0]
        else:
            if texts[1] == texts[2]:
                text = texts[1]
            else:
                text = texts[0]
        return text
    except:
        text = texts[0]
        return text


def coordinates_detection(img):
    text_coordinates = detect_text_blocks(img)
    texts = []
    font = cv2.FONT_ITALIC
    for coord in text_coordinates:
        top_left = (coord[0], coord[2])
        bottom_right = (coord[1], coord[3])
        x_min, y_min, x_max, y_max = coord[0], coord[2], coord[1], coord[3]
        if x_min >= 0 and x_max >= 0 and y_min >= 0 and y_max >= 0:
            cropped = img[y_min: y_max, x_min: x_max]
            text = transcription(cropped, 3, 3)
            texts.append(text)
            '''
            img = cv2.rectangle(img, top_left, bottom_right, (113,30,147), 3)
            img = cv2.putText(img, text, bottom_right, font, 0.5, (113,30,147), 2)
            print("{}: {}".format(coord, text))
    plt.figure(figsize=(10, 10))
    plt.imshow(img)
    while not plt.waitforbuttonpress():
        plt.imshow(img)
    #'''
    return texts


# Función que detecta bloques de texto y devuelve sus coordenadas
def detect_text_blocks(imagen):
    reader = easyocr.Reader(['es'])
    detection_result = reader.detect(img=imagen, width_ths=0.7, mag_ratio=1.5)
    text_coordinates = detection_result[0][0]
    return text_coordinates


# Función que rota la imagen dado un angulo concreto
def image_rotation_angle(img):
    osd = pytesseract.image_to_osd(img)
    angle = re.search(r'(?<=Rotate: )\d+', osd).group(0)
    return angle


# Función que divide las líneas de entrada por saltos igualmente espaciados
def lineas_entrada_salto(img, pag, img_dir, i, lineas):
    # Líneas entrada
    if pag == 0:
        lineas = {}
        j = 1
    totales = False
    config = utils.read_config()
    psm = 7
    key = config.get('Lineas entrada', 'Linea')
    coordIni, coordFin, modo = utils.coord_processing(key)

    salto = coordFin[1] - coordIni[1]

    while not totales and coordIni[1] < 2120:
        imgOut = img[coordIni[1]:coordFin[1], coordIni[0]:coordFin[0]]

        cf = list(coordFin)
        cf[1] = salto + coordFin[1]
        coordFin = tuple(cf)

        ci = list(coordIni)
        ci[1] =  salto + coordIni[1]
        coordIni = tuple(ci)

        # Transcripción de línea completa
        textL = transcription(imgOut, 3, psm)
        cv2.rectangle(img, coordIni, coordFin, (0, 255, 0), 2, 8)
        # Guarda la imagen en memoria
        # cv2.imwrite((img_dir + r'\\' + str(i) + '.tiff'), img)

        textL = textL.replace('"', "'")


        if not re.search(r'(Total B)+.*', textL) and not re.search(r'^o{1} ?', textL):
            if textL:
                detalles = {}
                #lineas['Concepto ' + str(j)] = textL
                # Detalles entrada
                for name, key in config.items('Detalles entrada'):
                    bordeIni, bordeFin, tipo = utils.coord_processing(key)
                    imgOut = img[coordIni[1]:coordFin[1], bordeIni[0]:bordeFin[0]]
                    text = transcription(imgOut, 3, psm)
                    text = text.replace('"', "'")
                    if re.search(r'^o{1} ?', text):
                        #totales = True
                        ...
                    detalles[name] = text

        else:
            totales = True
            j -= 1

        lineas['Concepto ' + str(j)] = detalles
        j += 1

        return lineas


# Función que divide el texto de líneas de entrada por sus saltos de línea
def lineas_entrada(img, c, lineas):
    imgOut, coords = utils.mouse_crop(img)
    #cv2.imshow('crop',imgOut)
    #cv2.waitKey(0)

    # Procesa el texto por la OCR
    # --psm 6 = Assume a single uniform block of text.
    text = transcription(imgOut, 3, 6)
    texts_list = text.splitlines()

    for j, line in enumerate(texts_list):
        line = line.strip()
        lineas['Concepto ' + str(j+c)] = line

    c += j+1
    totales = True
    return lineas, c


# 
def lineas_entrada_columna(img, c, lineas):
    imgOut, coords = utils.mouse_crop(img)

    if coords != [[[0, 0]],[[0, 0]]]:
        config = utils.read_config()
        line_details = {}
        for name, key in config.items('Detalles entrada'):
            coordIni, coordFin, modo  = utils.coord_processing(key)
            imgOut = img[coords[0][0][1]:coords[1][0][1], coordIni[0]:coordFin[0]]
            # --psm 4 = Assume a single column of text of variable sizes
            text = transcription(imgOut, 3, 4)
            # Divide la columna en líneas
            texts_list_raw = text.splitlines()
            # Aplicar preprocesamiento a la lista para evitar posibles vacios
            texts_list = []
            for line in texts_list_raw:
                # Quita espacios redundantes
                line = line.strip()
                if line != "":
                    texts_list.append(line)
            # Trata cada línea de forma independiente
            for j, line in enumerate(texts_list):
                concept = 'Concepto ' + str(j+c)
                if lineas.get(concept) is not None:
                    lineas[concept].update({name: line})
                else:
                    lineas[concept] = {name: line}
        c += j+1
    return lineas, c, coords


# Definición de dataframe a configurar
def structure_creation():
    COLUMN_NAMES = ['Factura Nº', 'Total', 'Fecha Factura']
    df = pd.DataFrame(columns=COLUMN_NAMES)
    return df


# Entrada del generado de imágenes a partir de pdfs
def images_generator(directorio_pdfs):
    logging.info('Directorio: ' + directorio_pdfs)
    try:
        pag_numbers = []
        with os.scandir(directorio_pdfs) as pdfs:
            for pdf in pdfs:
                if pdf.name.endswith('.pdf'):
                    logging.info('Pdf a tratar - ' + str(Path(pdf.path)))
                    pag_numbers.append(extract_image(Path(pdf.path), 0))
        return True, pag_numbers
    except Exception as e:
        logging.error(f'Imágenes no generadas ({e})')
        return False


# Extrae y estandariza como imagen la primera página de un pdf
def extract_image(pdfPath, pags=1):
    # pags = 0 extrae todas las imágenes del pdf
    img = utils.pdf_to_images(pdfPath, pags)
    logging.info('Inicio conversión pdf')
    # Guardar imagen
    for i, output in enumerate(img):
        images_dir = os.path.dirname(pdfPath) + r'\images'
        if not os.path.isdir(images_dir):
            os.mkdir(images_dir)
        cv2.imwrite((images_dir + r'\\' + Path(pdfPath).stem + f'_{i}' + '.tiff'), np.array(output))
        logging.info('Fin pdf')
    return i


'''
def modelo_convolucional():
    model = tf.keras.models.Sequential()

    # Añadimos la primera capa
    model.add(tf.keras.layers.Conv2D(64,(3,3), activation = 'relu', input_shape = (128,128,3)))
    model.add(tf.keras.layers.MaxPooling2D(pool_size = (2,2)))

    # Añadimos la segunda capa
    model.add(tf.keras.layers.Conv2D(64,(3,3), activation = 'relu'))
    model.add(tf.keras.layers.MaxPooling2D(pool_size = (2,2)))

    # Hacemos un flatten para poder usar una red fully connected
    model.add(tf.keras.layers.Flatten())
    model.add(tf.keras.layers.Dense(64, activation='relu'))

    # Añadimos una capa softmax para que podamos clasificar las imágenes
    model.add(tf.keras.layers.Dense(2, activation='softmax'))

    model.compile(optimizer="rmsprop",
                  loss='categorical_crossentropy',
                  metrics=['accuracy'])
'''