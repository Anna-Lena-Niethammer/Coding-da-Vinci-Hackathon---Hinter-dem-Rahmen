# Hinter dem Rahmen - Immersives XR Erlebnis

## Projektbeschreibung
Dieses Projekt ist für den Coding da Vinci Hackathon Baden-Württemberg 2022 in Verbindung mit meinem Master Projekt am Fachbereich Mensch-Computer-Interaktion der Uni Konstanz entstanden.
Im Rahmen des Hackathon haben diverse  Kulturinstitutionen Datensets unter offener Lizenz zur Verfügung gestellt mit denen gearbeitet werden konnte.

Dieses Projekt arbeitet mit Portraits, im spezifischen Fall der Prototype Demo den Gemälden von Franz Seraph Stirnbrand und bringt sie in die Virtuelle Welt.

Nicht nur Portraits selbst, sondern auch die dargestellten Personen haben eine Geschichte. Manche diese Geschichten lassen sich auch heute noch nachvollziehen - es sind Namen, Berufe, Wohnorte und noch so viel mehr über diese Personen bekannt.

Dieses Projekt zielt darauf ab Portraits mehr Raum zu geben ihre Geschichten zu vermitteln. Besucher sollen auf eine völlig neue Art und Weise mit den Gemälden interagieren können und sogar in sie eintauchen können.  
Ein Vorteil dieser Art von Präsentation ist, dass nur ein einzelner Raum statt einer ganzen Galerie benötigt wird.

Dem Besucher wird, nach Aufsetzen der VR Brille, an einer Wand eine Portraitsammlung präsentiert. Sobald ein Portrait ausgewählt ist, werden mehr Informationen über das Portrait und die Person angezeigt. Zusätzlich wird eine 3D Darstellung des Kopfes angezeigt. Durch das Aufheben eines Einladungsbriefes wird der Nutzer in eine VR-Umgebung mitgenommen, in der das Gefühl vermittelt wird selbst im Gemälde zu stehen.
## Verwendete Hard- & Software
Das Projekt wurde in Unity 2021.3.1f1 mit C# entwickelt.
Die Verwendete VR-Brille ist die [Varjo XR-3](https://varjo.com/).

Die 3-D Renderings der Köpfe wurden mithilfe von [Avatar-SDK](https://avatarsdk.com/) erstellt.

Verwendete Unity-Plugins:
* [Ultraleap Unity Plugin](https://developer.leapmotion.com/unity)
* [Varjo Unity XR SDK Plugin](https://developer.varjo.com/downloads#unity-developer-assets)

Verwendete Unity-Assets
 * [Victorian Interior](https://assetstore.unity.com/packages/3d/environments/historic/victorian-interior-148542)

Weitere Assets wurden von [CadNav](https://www.cadnav.com/) bezogen.
## Setup
Das Projekt ist auf die Verwendung mit der Varjo XR-3 und ihrer Funktionen ausgelegt. Das bedeutet im Folgenden wird das erfolgreiche Setup der VR Brille und die Verfügbarkeit ihrer Funktionen Vorausgesetzt. Es wird davon ausgegangen, dass die Varjo-XR entweder durch Inside-Out tracking oder durch die Verwendung von Lighthouses in der Lage ist ihre eigene Position im Raum zu bestimmen.

Als Requisiten wird von einem Schaufensterpuppenkopf auf einem Podest und einem Bilderrahmen mit Maßen 70x50cm ausgegangen. Zusätzlich werden die großen [Varjo-Marker](https://varjo-storage.s3.eu-central-1.amazonaws.com/docs/varjo-markers/VarjoMarkers-Object150mm-A4.pdf) 300 und 304 benötigt.

Der Rahmen wird an einer Wand befestigt und Marker 300 an der Wand neben dem Rahmen befestigt, so dass die rechte untere Kante des Markers bündig mit der linken unteren Kante des Rahmens ist.
[Bild]

Der Schaufensterkopf wird auf einem Podest befestigt. Marker 304 wird so an dem Podest befestigt, dass er bündig mit der oberen Kante des Podests ist.
[Bild]

Die Executable des Prototypen findet sich [hier](TODOLINK)

Mit diesem Setup sollte die Szene des Prototypen ordentlich ausgerichtet werden, sobald die Varjo-XR die Marker erkennt.

Im Verlauf des Prototypen kann der Nutzer mit zwei VR-Gegenständen interagieren, deren Zweck unter "Bedienung" genauer erklärt ist.
Aus diesem Grund ist aber darauf zu achten, dass der Brief in der Detailansicht und die Briefbox in der VR-Ansicht nicht innerhalb physikalischer Objekte im Raum liegen.
Es ist generell darauf zu achten, dass die Nutzer nicht durch im Weg liegende Objekte oder Möbel behindert werden, da sie ihnen in der VR-Ansicht nicht ausweichen können.
## Bedienung

### Galerie

Nach Start der Anwendung und dem Aufsetzen der VR-Brille findet sich der Nutzer in der Galerie-Ansicht wieder.
[Bild]

In dieser Ansicht ist es möglich sich verschiedene Portraits anzusehen und die Galerie durch greifen und ziehen  nach links oder rechts zu bewegen.
Hierfür ist es notwendig, dass der Nutzer zugreift, während er seine eigenen Hände sehen kann, seine Hand nach links oder rechts bewegt (abhängig von der gewünschten Bewegung) und den Griff wieder löst, während er weiterhin seine Hände sehen kann.
[Video]

Um über das Gemälde, das durch den Rahmen an der Wand hervorgehoben ist, mehr zu erfahren, kann der Nutzer das Gemälde greifen und nach unten ziehen. Hierfür ist es notwendig, dass der Nutzer zugreift, während er seine eigenen Hände sehen kann, seine Hand nach unten bewegt und den Griff wieder löst, während er weiterhin seine Hände sehen kann.
[Video]


### Detailansicht
Nach der oben beschriebenen Aktion befindet der Nutzer sich in der Detailansicht des ausgewählten Gemäldes.
[Bild]

Um wieder zur Galerie zurück zu kehren, greift der Nutzer auf Höhe des 3-D Kopfes und zieht in wieder nach oben. Hierfür ist es notwendig, dass der Nutzer zugreift, während er seine eigenen Hände sehen kann, seine Hand nach unten bewegt und den Griff wieder löst, während er weiterhin seine Hände sehen kann.
[Video]

Neben dem 3D-Kopf wird weiterhin eine "Einladung" dargestellt. Ein Greifen dieser Einladung führt dazu, dass der Nutzer sich in der VR-Umgebung wieder findet.
[Video]

### VR-Umgebung
Nach dem Eintreten in die VR-Umgebung hat der Nutzer weiterhin die Einladung in der Hand und ist in der Lage seine neue Umgebung zu erkunden. Um die VR-Umgebung zu verlassen kann der Nutzer die Einladung in eine Briefbox auf dem VR-Schreibtisch platzieren, um die VR-Umgebung zu verlassen und zur Detailansicht zurück zu kehren.
[Video]

## Weiterentwicklungsmöglichkeiten
### Unabhängigkeit vom Datenset
Weiterentwicklung des Prototypen würde es möglich machen, dass ein Datenset von Portraits (oder auch allgemein einfach nur Gemälden) dynamisch eingelesen werden könnte. 
Das würde bedeuten, durch Bereitstellung  der vom Programm vorausgesetzten Daten in einem gewissen Format (bestimmtes JSON Layout und Datenspeicherorte) könnte jeder Gemäldesatz auf die selbe Art und Weise dargestellt werden.
### Ausweitung der VR-Räumlichkeiten
Im Moment gibt es einen einzelnen VR-Raum, der für jedes Gemälde angezeigt wird. Da diese Räumlichkeiten sich aber im Realfall auf die Personen im Gemälde beziehen soll, ist ein Weiterentwicklungspunkt definitiv die Erstellung von Zeitalter und Standesgerechten Zimmern.
### Interaktion im VR-Raum
Der Prototyp gibt schon einen Hinweis darauf, dass es möglich sein kann einen 3D-Avatar der Person im Gemälde im VR-Zimmer auftauchen zu lassen. Dieser Avatar könnte dann mit dem Nutzer interagieren und z.B auch über eine Audiospur teile seiner Geschichte erzählen
### Franz Seraph Stirnband und die Gemälde der Stuttgarter Gesellschaft
Anstatt zu versuchen die Anwendung für weitere Datensets nutzbar zu machen, gibt es noch die Möglichkeit stattdessen die Anwendung weiter auf das vorhandene Datenset von Franz Seraph Strinbrand zu optimieren. 
Die Adressen der dargestellten Personen sind größtenteils bekannt und meist innerhalb der Stuttgarter Königstraße. 
Es wäre natürlich auch eine Möglichkeit, dem Nutzer die Möglichkeit zu geben das VR-Zimmer zu verlassen und, weiterhin virtuell, in der Stuttgarter Königstraße spazieren zu gehen und Persönlichkeiten der Gemälde zu besuchen.
## Quellcode
In diesem Git-Repository befindet sich, mit Ausnahmen, der Quellcode des Prototypen.
Aus Lizenzgründen wurden folgende Teile entfernt:
* Die 3D Modelle des Unity Asset Pakets Victorian Interieur (Weiterverbreitung der 3D Modelle außerhalb einer Anwendung nicht gestattet)
* Die 3D Modelle der Köpfe von Avatar SDK (Weiterverbreitung der 3D Modelle außerhalb einer Anwendung nicht gestattet)

Alle weiteren externen Plugins oder Modelle befinden sich in Unterordnern von "ThirdParty" und enthalten die jeweils geltenden Lizenzen.

## Credits
Dieses Projekt wurde von Anna-Lena Niethammer entwickelt.

Dabei wurde ich zum einen vom Personal des Stadtarchivs Stuttgart unterstützt, die als Datengeber des Datensets  [**#SchauMichAn - Franz Seraph Stirnbrand (um 1788-1882) und seine Porträts der Stuttgarter Gesellschaft**](https://codingdavinci.de/daten/schaumichan-franz-seraph-stirnbrand-um-1788-1882-und-seine-portraets-der-stuttgarter) und Berater bei Fragen bezüglich des Datensets fungiert haben.

Zum anderen wurde ich beraten und unterstützt vom Fachbereich Mensch-Computer-Interaktion der Universität Konstanz, die mir zusätzlich auch die Hardware und Räumlichkeiten zur Entwicklung des Prototypen zur Verfügung gestellt haben.

## License
[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://github.com/Anna-Lena-Niethammer/Coding-da-Vinci-Hackathon---Hinter-dem-Rahmen/blob/main/LICENSE)
