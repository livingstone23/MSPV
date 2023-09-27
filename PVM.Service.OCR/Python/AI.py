#import tensorflow as tf
#from tensorflow import keras
#from keras import layers
#import PIL
import logging
import os
import utils
from pathlib import Path
import numpy as np
import pandas as pd
import cv2
#import tflearn

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
def model_for_classification():
    # Classification
    tflearn.init_graph(num_cores=8, gpu_memory_fraction=0.5)

    net = tflearn.input_data(shape=[None, 1400])
    net = tflearn.fully_connected(net, 64)
    net = tflearn.dropout(net, 0.5)
    net = tflearn.fully_connected(net, 10, activation='softmax')
    net = tflearn.regression(net, optimizer='adam', loss='categorical_crossentropy')

    model = tflearn.DNN(net)
    return model
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

