## UML: Unified Modeling language
---

The UML is a standardized form of drawing programs. It uses boxes and lines to describe functions and calls. This allows better communication between programmers even if they program in different languages. The reason for this is that this technique describes how to communicate programming logic through diagrams therefore not concerning syntax of any kind. There are even programs that let you code with UML, those are the visual scripting languages and they are used to let logic programming more approachable for non programming individuals. Examples of this are in blender and unity development environment and are common in shader programming.

# Some common symbols

- Boxes: They symbolize classes. Within it rests the properties and methods listed in the box. It summarizes all that there is in the module.

                +-------------------------------+
	        |      name_of_class            |               __________________.
		|-------------------------------|              |                   \
		| +variable:int                 |              |____________________\___________.
		| -variable2:int=30             |              |                                |
		| -variable3:int {readOnly}     | -----------> |  dados ou classe (dependencia) |
		| #variable4:Boolean=true       |              |                                |
		+-------------------------------+              +--------------------------------+
		| +function1():int              |
		| -function2(int a, int b):int  |
		+-------------------------------+                  A -------> B   (A usa B)


Neste exemplo podemos ver como as propriedades e métodos se organizam dentro da função. Os símbolos a esquerda indicam se a função é pública ou privada da classe. Ou se é protegida. Uma legenda pode acompanhar o diagrama para especificar esse tipo de informação. Depois dos dois pontos vem o que a variável contém, ou o que a função retorna. As setas indicam dependências. Isso pode ser um conjunto de dados que a classe usa, ou outra classe. 

