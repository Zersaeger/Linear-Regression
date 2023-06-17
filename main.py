import numpy as np
from sklearn.linear_model import LinearRegression
import pandas as pd

data = pd.read_csv("C:\\Users\\leona\\Code\\Python\\ML\\Learn\\data.csv")

time_studied = np.array(data.studytime).reshape(-1, 1)
scores = np.array(data.score).reshape(-1, 1)

model = LinearRegression()
model.fit(time_studied, scores)

print(model.predict(np.array([56]).reshape(-1, 1)))
