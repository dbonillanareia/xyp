# XYP07

# xyp08

 - Qué se puede compartir?
 	- invocaciones a servicios
 	- parsear datos
 	- usar storage
 	- logica de negocio o procesamiento 	
- Cuándo no se puede compartir?
	- access system information 
	- use files and folder on the device
	- access personal information
	- use external devices
- Shared project y shared binaries
- Shared project
	- single copy of source file?
	- compiled uniquely into project?
	- tipo de archivo? shproj
	- estrategias platform specific code
		- conditional compilation
		- class mirroring
		- partial classes + methods
- PCL
	- estrategias platform specific code
		- callbacks
		- Platform abstractions

MIRRORING
		
```csharp
	public class NoteManager 
	{	   void CloudBackupComplete() 
	   {      		Alert.Show("Success!", "Notes have been backed up.");
		} 
	}
```
iOS

```csharp
	class Alert 
	{		internal static void Show(string title, string message) 
		{			new UIAlertView(title, message, null, "OK") .Show();		} 
	}
```
Droid

```csharp
	class Alert 
	{		internal static void Show(string title, string message) 
		{			new AlertDialog.Builder(Application.Context) 
				.SetTitle(title)				.SetMessage(message)		}
	}
```	


PARTIAL CLASSES
Shared

```csharp
partial class NoteManager {	void OnDeleteNote() 
	{		if (ShowAlert("Warning!", "...")) {		... 	
		}	} 
}
```	

iOS

```csharp
partial class NoteManager{   bool ShowAlert(string title, string msg) 
  	{		... 
	}}
```	

PARTIAL Methods
Shared

```csharp
partial class NoteManager 
{   partial void ShowPrintSettings();
      void PrintNote(NoteItem note) 
   {     ...     ShowPrintSettings();	} 
}
```	

iOS

```csharp
partial class NoteManager 
{   // No definition of method}
```	

PCL
Callbacks

PCL

```csharp
public class Dialer{	public static Func<string,bool> MakeCallImpl;	
	public bool MakeCall(string number) 
	{  		if (MakeCallImpl(number)) {			... 
		}	} 
}

```	

iOS


```csharp

 Dialer.MakeCallImpl = number => 
 {  	return UIApplication       .SharedApplication
       .OpenUrl(new NSUrl("tel: " + number));
 }

```	

Platform abstractions
interfaz / implementación