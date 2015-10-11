CAD to Unity
============

This project is a collection of libraries and helpers to simplify the process of importing a CAD model into a Unity3D based application on runtime.


## Possible formats

 * CATPart: 3D-Daten allgemein (Drahtgeometrie, Flächen, Körper); Workbenches: Part-Design, Generative-Shape-Design, Sketcher,..
 * CATProduct: Räumliche Anordnung und Organisation von CATParts und anderen CATProducts sowie weitere Meta-Daten wie Constraints, Sections, Annotations, Measures, Scenes, Workbench: Assembly-Design
 * CATDrawing: Zeichnungen, 2D-Daten; Workbench: Interactive Drawing
 * cgr: Datenformat zur tesselierten Darstellung von 3D-Daten, Workbench: Assembly-Design (im Visualisierungsmodus mit Cache)
 * igs/iges: Für 3D- oder 2D-Daten (Zeichnungen)
 * stp/step: Für 3D-Daten und Metadaten, mit Protokollen (Varianten): AP214, AP203,..
 * stl: Für 3D-Daten, tesseliertes, weit verbreitetes Format, große Datenmenge
 * wrl/vrml: Für 3D-Daten, tesseliertes und komprimiertes Format mit Texturen
 * 3dxml: Für 3D-Daten, neues tesseliertes Format von Dassault, kostenloser Viewer

##Format 

#iges/iges

* supports the following models: circuit diagrams, wireframe, freeform surface or solid modeling representations.
* single parts are stored as entities (https://de.wikipedia.org/wiki/Initial_Graphics_Exchange_Specification)
* files can be saved in ascii and binary format, however the last one is not supported anymore.
 
#stp/step

* wide spread
* files are saved in ascii
* one instance/part per line is the convention, but multiple files can be saved in one line
* defined in ISO 10303-21, better walk away?
* ISO 10303-21 defines the encoding mechanism on how to represent data according to a given EXPRESS schema, but not the EXPRESS schema itself.

#stl

* wide spread
* standard use case rapid prototyping, 3D printing and computer-aided manufacturing
* describe only the surface geometry of a three-dimensional object without any representation of color, texture or other common CAD model attributes
* supports acsii and binary formats

#wrl/vrml

* is a standard file format for representing 3-dimensional (3D) interactive vector graphics
* has been superseded by X3D(iso standard)

#3dxml
* uses xml to describe 3D geometries
* no to be confused with x3D 
* 3DXML format is only supported by Dassault Systèmes product line
