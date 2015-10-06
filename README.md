CAD to Unity
============

This project is a collection of libraries and helpers to simplify the process of importing a CAD model into a Unity3D based application on runtime.

CATPart      3D-Daten allgemein (Drahtgeometrie, Flächen, Körper)
             Workbenches: Part-Design, Generative-Shape-Design, Sketcher,..
CATProduct   Räumliche Anordnung und Organisation von CATParts und anderen CATProducts
             sowie weitere Meta-Daten wie Constraints, Sections, Annotations, Measures, Scenes,
             Workbench: Assembly-Design
CATDrawing   Zeichnungen, 2D-Daten
             Workbench: Interactive Drawing
cgr          Datenformat zur tesselierten Darstellung von 3D-Daten, 
             Workbench: Assembly-Design (im Visualisierungsmodus mit Cache)
CATVbs       Visual Basic (Microsoft kompatible Scriptsprache)
CATScript    Dassault-Scriptsprache

CATIA V5 verwendet außerdem folgende Dateiformate für interne und administrative Zwecke:

CATSettings    Benutzereinstellungen (eingestellt unter Tools/Options.. und Tools/Customize..)
XML            Exportierte CATSettings, Editieren und Import in CATSettings möglich
CATPreferences Temporäre Benutzereinstellungen während der laufenden Arbeit

Kompatible Dateiformate

CATIA V5 arbeitet auch mit folgenden systemneutralen oder weit verbreiteten Formaten anderer Hersteller
(abgesehen von Direktschnittstellen zu bestimmten anderen CAD-Systemen):

igs/iges     Für 3D- oder 2D-Daten (Zeichnungen)
stp/step     Für 3D-Daten und Metadaten, mit Protokollen (Varianten): AP214, AP203,..
stl          Für 3D-Daten, tesseliertes, weit verbreitetes Format, große Datenmenge
wrl/vrml     Für 3D-Daten, tesseliertes und komprimiertes Format mit Texturen
3dxml        Für 3D-Daten, neues tesseliertes Format von Dassault, kostenloser Viewer

dxf/dwg      Für 2D-Daten (in CATIA) kompatibel u.a. zum Ursprungssystem: AutoCAD
cgm          Für 2D-Daten, Plotting-Format (mit Untertypen wie iso, cals u.a.)
hpgl/hpgl2   Für 2D-Daten, Hewlett-Packard-Plotting-Language (V1 ascii, V2 binär)
pdf          Für 2D-Daten, Dokumenten-Beschreibungsformat (Ursprung: Adobe Reader)

xls          Tabellenkalkulation (Ursprung: MS Excel)
csv          Tabelle/Datenbank in Textformat mit Trennzeichen für Feld-Kennzeichnung
