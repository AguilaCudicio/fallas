import abc

from Rule import * 
from abc import ABCMeta

class IfContains(Rule):
    "Si facts contiene la lista de hipotesis, va a devolver la lista"
    "res de hechos"
    def __init__(self,hyp,res):
         Rule.__init__(self)
         self.hypothesis=hyp
         self.result=res
         

    def calculate(self,facts):
         for x in self.hypothesis:
            if not x in facts:
                return null;
         return self.result