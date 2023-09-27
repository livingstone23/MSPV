import re
import pdf2image as pdf2i
import os
import numpy as np
import cv2
import logging
from shutil import rmtree
import pytesseract
import helper


# Variables globales
top_corner = [[0, 0]]
bottom_corner = [[0, 0]]
draw = False
undo = False


# Convierte los documentos pdf a imágenes
def pdf_to_images(pdfPath, num=0):
    images = []
    img = pdf2i.convert_from_path(pdfPath, poppler_path=os.path.abspath(r'.\Python\poppler-0.68.0\bin'))
    if num == 0:
        for i in range(len(img)):
            images.append(cv2.cvtColor(np.array(img[i]), cv2.COLOR_BGR2RGB))
    else:
        for i in range(len(img)):
            if i < num:
                images.append(cv2.cvtColor(np.array(img[i]), cv2.COLOR_BGR2RGB))
    return images


# Devuelve las coordenadas almacenadas en el config
def coord_processing(key):
    coord = key.split(', ')
    coordIni = tuple(map(int, coord[0].split(':')))
    coordFin = tuple(map(int, coord[1].split(':')))
    modo = int(coord[2])
    return coordIni, coordFin, modo


# Limpia todas las imágenes de la ubicación correspondiente
def dispose_images(imgPath):
    try:
        if imgPath.endswith('images'):
            rmtree(imgPath)
            return True
    except:
        return False


# Devuelve dos vectores, el primero contiene las imágenes de la carpeta especificada y el segundo sus nombres
def load_images_from_folder(folder):
    images = []
    img_names = []
    for filename in os.listdir(folder):
        img = cv2.imread(os.path.join(folder, filename))
        if img is not None:
            images.append(img)
            img_names.append(filename)
    return images, img_names


# Funcion que es llamada cada input de ratón para activar el dibujado de un rectángulo
def draw_rectangle(action, x, y, flags, *userdata):
    # Referencing global variables
    print(x, ' ', y)
    global top_corner, bottom_corner, draw, undo

    # Mark the top left corner when left mouse button is pressed
    if action == cv2.EVENT_LBUTTONDOWN:
        top_corner = [[x, y]]
        draw = False

    # When left mouse button is released, mark bottom right corner
    elif action == cv2.EVENT_LBUTTONUP:
        # Setteo y comparación de coordenadas 'y'
        if top_corner[0][1] < y:
            bottom_corner[0][1] = y
        else:
            bottom_corner[0][1] = top_corner[0][1]
            top_corner[0][1] = y

        # Setteo y comparación de coordenadas 'x'
        if top_corner[0][0] < x:
            bottom_corner[0][0] = x
        else:
            bottom_corner[0][0] = top_corner[0][0]
            top_corner[0][0] = x
        undo = True
        draw = True


def resize_img(img, scale_percent):
    # Escala una imagen en relación con el porcentaje dado
    width = int(img.shape[1] * scale_percent / 100)
    height = int(img.shape[0] * scale_percent / 100)
    dim = (width, height)
    # resize image
    resized = cv2.resize(img, dim, interpolation=cv2.INTER_AREA)
    return resized


# Hace rotar a la imagen x grados
def rotate_img(image, angle):
  image_center = tuple(np.array(image.shape[1::-1]) / 2)
  rot_mat = cv2.getRotationMatrix2D(image_center, angle, 1.0)
  rotated = cv2.warpAffine(image, rot_mat, image.shape[1::-1], flags=cv2.INTER_LINEAR)
  return rotated


def mouse_crop(img):
    # Muestra la imagen de la factura y permite hacer un recorte de la misma.
    global top_corner, bottom_corner, draw, undo
    # Prepara la ventana donde se va a mostrar la imagen
    winname = 'Seleccion a procesar | Enter para aceptar'
    cv2.namedWindow(winname)

    # Crea el trigger que va a activarse 
    cv2.setMouseCallback(winname, draw_rectangle)

    screen = helper.screen_dim()
    img_r, resized = resize_aspect_ratio(img, height=screen[1]-50)
    img_r_cache = img_r.copy()

    while (1):
        if undo:
            img_r = img_r_cache.copy()
            undo = False
        cv2.imshow(winname, img_r)
        print(top_corner)
        print(bottom_corner)
        print('-------------')
        if bottom_corner != [[0, 0]] and draw:
            cv2.rectangle(img_r, top_corner[0], bottom_corner[0], (255, 50, 25), 2)
            draw = False
        if cv2.waitKey(20) & 0xFF == 13:
            break
    # Limpia las ventanas generadas
    cv2.destroyAllWindows()
    # Calcula las coordenadas para la imagen original
    top_resized = [[int(top_corner[0][0]/resized), int(top_corner[0][1]/resized)]]
    bottom_resized = [[int(bottom_corner[0][0]/resized), int(bottom_corner[0][1]/resized)]]
    # Recorta la parte correspondiente de la imagen original
    cropImg = img[top_resized[0][1]:bottom_resized[0][1], top_resized[0][0]:bottom_resized[0][0]]
    #cv2.imshow("Cut", cropImg)
    #cv2.waitKey()
    return cropImg, [top_resized, bottom_resized]


# Mantiene la relaccion de aspecto y redimensiona la imagen entrante
def resize_aspect_ratio(image, width=None, height=None):
    r = 1.
    dim = None
    (h, w) = image.shape[:2]

    if width is None and height is None:
        return image
    if width is None:
        r = height / float(h)
        dim = (int(w * r), height)
    else:
        r = width / float(w)
        dim = (width, int(h * r))
    
    if r > 0.01:
        image = cv2.resize(image, dim, interpolation=cv2.INTER_LINEAR)
    else:
        r=1

    return image, r


# Sustituye los saltos de línea y quita los espacios de los laterales de la cadena.
def trim(text):
    text = text.replace("\n", " ")
    text = text.strip()
    return text


# Guarda el texto en la ruta correspondiente
def text_save(text, name, path):
    # Preparar ruta para la subida de la transcripción de texto
    txt_dir = path + r'\texts\\'
    if not os.path.isdir(txt_dir):
        os.mkdir(txt_dir)
    txt_path = txt_dir + name + '.txt'

    # Abrir fichero y guardar el texto correspondiente en un archivo aparte
    with open(txt_path, 'w') as f:
        # Escritura de la salida del comparador de textos
        f.write(text)
        f.close()


def convert_grayscale(img):
    img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    return img


def blur(img, amount):
    img = cv2.medianBlur(img, amount)
    return img


def threshold(img):
    img = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]
    return img


