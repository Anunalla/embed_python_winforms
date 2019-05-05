# embed_python_winforms

	Details of the architecture:

	OS                  : Windows 10 64 bit 
	python              : ver 3.5.0 (x86) 
	pythonnet           : ver 2.4.1.0 (x86) 
	Visual Studio       : Community ver 2019 
	project architecture: x86

	Steps to set up the environment:

	1.Install python 3.5 
    	https://www.python.org/downloads/release/python-350/
	2.Add python's folder and Lib folder in the Path environment variable
	3.Install pythonnet using pip pip install pythonnet 
    	Note: requires the wheel package.
	4.Install any other python libraries that you'd be using in the winforms appln.
	5.Add the path of Python.Runtime.dll to the winforms reference list: 
    	(Project→Add preferences menu in VS) 
    	Note: the DLL file would be located in the "...\Python 3.5\Lib\site-packages" folder.
	Note: Using pythonnet from Nuget package is not recommended.
	It is hard to get the python installations and the winform architectures to match.
	Installing pythonnet using pip is a lot easier.
