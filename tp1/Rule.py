import abc


from abc import ABCMeta

"Las reglas van a ser clases abstractas"
"Se calcula si la regla se cumple dada una lista de hechos"
class Rule(object):

     __metaclass__ = ABCMeta
     
     @abc.abstractmethod
     def calculate(self,facts):
         print "Soy abstracto, no instanciarme"