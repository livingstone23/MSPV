from tabulate import tabulate
import pandas as pd
import numpy as np
import threading
import logging
import helper
import utils
import json
import OCR
import cv2
import AI
import re
import os


def main():
    # Inicializando el logger y la configuración de Tesseract
    helper.setup_logger()
    helper.setup_tesseract_ocr()
    # Cargar configuracion
    config = helper.read_config()
    try:
        # Obtener el directorio especificado en la configuración
        dir = config.get('Pdfs', 'directorio')
        if dir is not None:
            # Generar las imagenes de las facturas
            generadas, paginas = AI.images_generator(dir)
            if generadas:
                # cargar imágenes generadas
                img_dir = dir + r'\images'
                images, img_names = utils.load_images_from_folder(img_dir)

            # Crear un dataframe con la información estructurada de la factura
            df = AI.structure_creation()
            print(tabulate(df, headers='keys', tablefmt='psql'))
            print(df)
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
                    ...
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


def testing():
    ...


# Main entrance
if __name__ == '__main__':
    #main()
    helper.setup_logger()
    helper.setup_tesseract_ocr()
    #templateGenerator.init()
    #testing()
