import os

os.system('git add .')
s = input("Please input commit:\n")
os.system('git commit -m \"' + s + '\"')
os.system('git push origin master')
