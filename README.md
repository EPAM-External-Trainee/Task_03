# .NET Summer 2020 (external)
## Task03. Inheritance. Interfaces and Abstract Classes
### Task
* 1.1. Develop a class hierarchy to solve the problem, using the capabilities of OOP: classes, inheritance, polymorphism, encapsulation, interface capabilities and multiple inheritance, use the capabilities of Enum and inner classes.
* 1.2. Each class should have a comprehensive meaning, name and informative composition.
* 1.3. Classes are grouped according to their meaning in the corresponding class libraries.
* 1.4. When coding, the C # code convention must be used.
* 1.5. Classes must have ToString(), GetHashCode() and Equals() methods.
* 1.6. Using the StreamReader and StreamWriter classes to ensure loading/saving data from an XML file.
* 1.7. Using the XmlReader and XmlWriter classes, ensure that data is read/saved to an XML file.
* 1.8. Provide mutual reading/saving of data by the XmlWriter and StreamReader, StreamWriter and XmlReader classes.
* 1.9. A Wide range of data types, different levels of access to fields and methods, the use of static fields and methods, and constants are welcome.
* 1.10. The girl has dimensionless sheets of film and paper. From them, she can cut various geometric shapes (circle, rectangle, equilateral triangle, etc.) of a certain size, and from some shapes, you can cut others. The shape to be cut must be smaller than the one it is being cut from.
* 1.11. Also, girl have a set of paints. Paper figures can be painted, but only 1 time. Figures from the film are colorless and can't be painted.
* 1.12. All figures must provide the ability to calculate the area and perimeter.
* 1.13. Also, the girl has a box for 20 figures, where you can put and get any figures.
* 1.14. The box has a number of functions:
1. add a shape, (you can't add the same shape twice);
2. view by number (the shape remains in the box);
3. extract by number (this removes the shape from the box);
4. replace by number;
5. find a shape based on the sample (equivalent in its characteristics);
6. show the available number of figures;
7. total area;
8. total perimeter;
9. to get all the Circles;
10. get all the Film shapes;
11. save all shapes / paper only / film only from the box to an XML file using StreamWriter;
12. save all shapes / paper only / film only from the box to an XML file using XmlWriter;
13. upload all shapes to the box from an XML file using StreamReader;
14. upload all shapes to the box from an XML file using XmlReader;
* 1.15. Requirements to implement:
1. material and shape may not be fields of the class;
2. cut a shape from another shape to implement as resp. constructor;
3. use Enum features with color;
4. the impossibility of cutting implement as appropriate the exception;
5. the inability to color the shape is implemented as a corresponding exception;
6. auto documentation must be used;
7. implement unit tests for developed classes;
