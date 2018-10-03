@ECHO OFF
ECHO "Start ERM automated trial tests"
"C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe" --result ".\TestResult.xml" ".\ERM.AutomationTrial\bin\Debug\ERM.AutomationTrial.dll"
ECHO "Test completed"

ECHO "Generating Live documents using pickles"
.\packages\Pickles.CommandLine.2.19.0\tools\pickles.exe --feature-directory=.\ERM.AutomationTrial\Features --output-directory=.\Documentation --link-results-file=.\TestResult.xml --documentation-format=dhtml  -trfmt=nunit3 -exp

ECHO "Opening Reports"
.\Documentation\index.html