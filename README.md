## Info. Importante
 
<a href="https://miro.com/app/board/uXjVOzysLCs=/">Miro</a><br>
Version de Unity: 2021.3.6f1

## Clean Code

### Nomenclatura:
    • Clases: CapitalCamelCase en inglés
    • Variables y funciones públicas: CapitalCamelCase en inglés
    • Variables y funciones privadas: camelCase en inglés

### Modularización:
    • Las funciones deben realizar una única tarea y tomar la cantidad de parametros mínima necesaria para la ejecución.
    • Las clases controlan un único aspecto y se encuentra ordenada para fácil lectura.
    • Siempre respetar las jerarquías y competencias de las clases.
    • Procurar mantener la mínima cantidad de líneas posibles para una función aunque priorizando la funcionalidad y optimización antes que lo dicho.

### Variables y funciones:
    • Declarar las variables necesarias siempre al inicio de la clase o función a menos que no sea posible.
    • Declarar las variables y funciones como privadas a menos que sea necesaria una publica
    • Ordenar las variables al inicio de la clase de la siguiente manera
```
        1. Publicas con argumento (SerializeField, HideInInspector, Range, etc) colocando más arriba las que más contengan.
        2. Privadas con argumentos siguiendo las mismas prioridades que lo anterior mencionado.
        3. Publicas sin argumentos.
        4. Privadas sin argumentos.
```

### Conceptos:
    • Manager: Un unico script y objeto por escena, controla multiples objetos y/o controladores.
    • Controller: Controla un único objeto y los scripts hijos.
