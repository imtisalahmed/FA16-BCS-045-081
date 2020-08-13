import re
import scipy
import string
import pickle
import warnings
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import sklearn.utils._cython_blas
import sklearn.neighbors.typedefs
import sklearn.neighbors.quad_tree
import sklearn.tree
import sklearn.tree._utils

from sklearn.preprocessing import LabelEncoder            
from sklearn.svm import LinearSVC             
from sklearn.naive_bayes import BernoulliNB
from sklearn.ensemble import RandomForestClassifier          
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score    

from prettytable import PrettyTable   
from astropy.table import Table, Column 

Best_classifier = pickle.load(open('random_forest_classifier.pkl', 'rb'))
test_file_path = "C:/Users/92336/Documents/test.csv"

# reading train/test dataset
text = open(test_file_path, "r")
text = ''.join([i for i in text]) \
    .replace("Infinity", "0")
x = open(test_file_path,"w")
x.writelines(text)
x.close()
test_dataset = pd.read_csv(test_file_path)
print(test_dataset)
#C_Temp=test_dataset.iloc[:, :-120].values
new_test_dataset = pd.read_csv("C:/Users/92336/Documents/test.csv", usecols=np.r_[1:85])
print(new_test_dataset)
new_test_dataset = np.loadtxt(
  "C:/Users/92336/Documents/test.csv", 
  delimiter=",", 
  skiprows = 1, 
  usecols=np.r_[1:85]
)
print(new_test_dataset)
np.savetxt("new_test_dataset.csv", new_test_dataset, delimiter=",")
prediction = Best_classifier.predict(new_test_dataset)
print(prediction)
import numpy
numpy.savetxt("Result.csv", prediction, delimiter=",")

