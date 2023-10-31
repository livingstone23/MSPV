from tabulate import tabulate
import numpy as np
import logging
import utils
import json
import OCR
import os


#'''
# Funcion principal que se encarga de la extracción de datos de las facturas de un directorio
def main():
    # Inicializando el logger y la configuración de Tesseract
    utils.setup_logger()
    utils.setup_tesseract_ocr()
    # Cargar configuracion
    config = utils.read_config()
    try:
        # Obtener el directorio especificado en la configuración
        dir = config.get('Pdfs', 'directorio')
        if dir is not None:
            # Generar las imagenes de las facturas
            generadas, paginas = OCR.images_generator_old(dir)
            if generadas:
                # cargar imágenes generadas
                img_dir = dir + r'\\images'
                images, img_names = utils.load_images_from_folder(img_dir)

            # Control de documentos
            doc = 0
            
            # Recorrer cada imagen
            for i, img in enumerate(images):
                # Detectar orientaciones y desplazamientos en la imagen
                imgdata = OCR.osd(img)
                # rotate the image to correct the orientation
                rotated = utils.rotate_img(img, angle=imgdata["rotate"])
                data = {}

                # Detalles factura
                pag = int(img_names[i].split('_')[-1].split('.')[0])
                if pag == 0:
                    detalles = {}
                    for name, key in config.items('Detalles factura'):
                        coordIni, coordFin, modo  = utils.coord_processing(key)
                        imgOut = img[coordIni[1]:coordFin[1], coordIni[0]:coordFin[0]]

                        psm = 7
                        if modo == 1:
                            psm = 3

                        text = OCR.transcription(imgOut, 3, psm)
                        text = utils.trim(text)

                        detalles[name] = text

                    data['Detalles factura'] = detalles
                else:
                    data['Detalles factura'] = {}
                
                # Líneas entrada
                if pag == 0:
                    lineas = {}
                    c = 1
                lineas, c, coords = OCR.lineas_entrada_columna(img, c, lineas)
                #lineas, c = OCR.lineas_entrada(img, c, lineas)
                #lineas = OCR.lineas_entrada_salto(img, pag, img_dir, i, lineas)
                data['Lineas entrada'] = lineas

                # Totales
                if pag == paginas[doc]:
                    totales_data = {}
                    psm = 5
                    # Falta añadir la funcionalidad de los totales
                    data['Totales'] = totales_data
                    doc += 1

                # Unificación de información de ficheros con más de una página
                if pag != 0:
                    # Referenciar directorio anterior
                    re_pag = dir + r'\texts\\' + img_names[i - 1].split('.')[0] + '.txt'
                    archivo = open(re_pag, mode='r')
                    # Cargar json anterior
                    json_0 = json.loads(archivo.read())
                    # Cerrar archivo temporal
                    archivo.close()
                    os.remove(re_pag)

                    # Combinar información de los diccionarios nuevo y antiguo
                    data['Detalles factura'] = json_0['Detalles factura']
                    lineas_entrada = json_0['Lineas entrada']
                    data['Lineas entrada'] = lineas_entrada | lineas
                
                # Volcar información a una solo json
                json_data = json.dumps(data)
                json_data = json_data.replace("\\n", " ")
                
                # Guardar texto
                utils.text_save(json_data, img_names[i].split('.')[0], dir)
            
            logging.info('Proceso finalizado')
            
            # Una vez analizadas las imágenes se borran para optimizar memoria
            print(utils.dispose_images(img_dir))

    except Exception as e:
        logging.error(f'Error en el proceso OCR ({e})')
        print('Imagenes borradas:')
        print(utils.dispose_images(img_dir))
        print("Error, excepción: " + e)
        return False
#'''


# Extrae el texto de un pdf dado o una carpeta que los contenga, junto a una plantilla, con un GUID de control
def extract_pdf(GUID, pdf_path, plantilla_json):
    try:
        if pdf_path is not None:
            # Setteo del logger
            utils.setup_logger()
            # Generar las imagenes de las facturas
            imagenes, nombres  = OCR.generador_imagenes(pdf_path)
            return extract(GUID, imagenes, nombres, plantilla_json)
        else:
            raise Exception
    
    except Exception as e:
        logging.error(f'Error en el proceso OCR ({e})')
        # Crea un JSON de respuesta que contiene la excepción y lo devuelve
        json_respuesta = [{"GUID": GUID},{"content":""},{"Sucess":False},{"Message":f"{e}"}]
        return json.dumps(json_respuesta)


# Extrae el texto de una serie de imagenes dadas junto a sus nombres aplicando una plantilla, cuenta con un GUID de control
def extract(GUID, imagenes, nombres, plantilla_json): 
    try:
        # Inicialización de json de respuesta, añadiendo GUID primero para que se mantenga un control sobre la llamada
        json_respuesta = [{'GUID': GUID}]
        
        # Inicializando el logger si no ha sido inicializado (el nivel por defecto es Warning == 30, el aplicado en el setteo es Debug == 10 )
        if logging.getLogger().getEffectiveLevel() == 30:
            utils.setup_logger()
        # Inicializa la configuración de Tesseract
        utils.setup_tesseract_ocr()

        # Cargar configuracion
        config = utils.read_config()

        # Carga de plantilla desde su JSON
        plantilla = json.loads(plantilla_json)

        # Añadir código restante del main_restante a partir de la siguiente línea
        # ...
        # Estado actual devuelve un array con las imágenes generadas
        # logging.info(imagenes)
        # logging.info(np.shape(imagenes))

        # Devuelve el json de respuesta
        return json.dumps(json_respuesta)

    except Exception as e:
        # Escribe en el log que ha habido un error
        logging.error(f'Error en el proceso OCR ({e})')
        # Genera y devuelve el JSON de respuesta con la excepción
        json_respuesta = [{"GUID": GUID},{"content":""},{"Sucess":False},{"Message":f"{e}"}]
        return json.dumps(json_respuesta)


# TODO: resto del main a transcribir al método extract(...)
def main_restante(images):
    # Recorrer cada imagen
    for i, img in enumerate(images):
        # Detectar orientaciones y desplazamientos en la imagen
        imgdata = OCR.osd(img)
        # rotate the image to correct the orientation
        rotated = utils.rotate_img(img, angle=imgdata["rotate"])
        data = {}

        # Detalles factura
        pag = int(img_names[i].split('_')[-1].split('.')[0])
        if pag == 0:
            detalles = {}
            for name, key in config.items('Detalles factura'):
                coordIni, coordFin, modo  = utils.coord_processing(key)
                imgOut = img[coordIni[1]:coordFin[1], coordIni[0]:coordFin[0]]

                psm = 7
                if modo == 1:
                    psm = 3

                text = OCR.transcription(imgOut, 3, psm)
                text = utils.trim(text)

                detalles[name] = text

            data['Detalles factura'] = detalles
        else:
            data['Detalles factura'] = {}
        
        # Líneas entrada
        if pag == 0:
            lineas = {}
            c = 1
        lineas, c, coords = OCR.lineas_entrada_columna(img, c, lineas)
        #lineas, c = OCR.lineas_entrada(img, c, lineas)
        #lineas = OCR.lineas_entrada_salto(img, pag, img_dir, i, lineas)
        data['Lineas entrada'] = lineas

        # Totales
        if pag == paginas[doc]:
            totales_data = {}
            psm = 5
            # Falta añadir la funcionalidad de los totales
            data['Totales'] = totales_data
            doc += 1



# Función destinada a pruebas para poder hacer un seguimiento independiente a partes específicas del programa
def testing():
    # Puestos los tres puntos para que no falle el programa al compilar
    ...


# Main entrance
if __name__ == '__main__':
    #main()
    #testing()

    # Puestos los tres puntos para que no falle el programa
    ...
