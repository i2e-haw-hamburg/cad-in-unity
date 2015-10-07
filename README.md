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
