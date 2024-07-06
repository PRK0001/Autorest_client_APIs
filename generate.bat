pushd "%~dp0"
@echo "%~dp0"
rd PowerBI.Api\Source\ /s /q

@echo Generating code using powerbi.md
call AutoRest --version=3.10.2 powerbi.md
popd
@echo Autorest run sucessfully