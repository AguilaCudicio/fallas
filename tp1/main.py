#!/usr/bin/python
from Rule import * 
from IfContains import * 

print "Hello, Python!"

"Los hechos van a ser strings"
facts=['p','q','r','s'];

"Si p y q, entonces s"
v1 = IfContains(['p','q'],['s'])
print(v1.calculate(facts))
