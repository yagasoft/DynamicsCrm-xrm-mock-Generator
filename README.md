# DynamicsCrm-xrm-mock-Generator
### Version: 1.1.2.1
---

An XrmToolBox plugin that can be used to generate the XRM form model for xrm-mock testing framework.

## Usage

+ Load data
+ Choose an entity
+ Select forms
+ Generate model
+ Build the model before testing

```ts
const builder = new XrmModel.ModelBuilder(new XrmModel.account());
builder.selectForm("Account");
builder.buildModel();
```

A detailed guide will be released soon.

## Credit

+ camelCaseDave
  + xrm-mock
  + https://github.com/camelCaseDave/xrm-mock
		
## Changes

#### _v1.1.2.1 (2018-08-19)_
+ Fixed: control creation error in template
+ Fixed: sections array error in template
+ Fixed: misidentifying grids in form XML
#### _v1.1.1.3 (2018-08-18)_
+ Added: entity filter
+ Added: button icons
+ Added: reuse latest path to save/load settings
#### _v1.0.3.2 (2018-08-17)_
+ Initial release

---
**Copyright &copy; by Ahmed el-Sawalhy ([Yagasoft](http://yagasoft.com))** -- _GPL v3 Licence_
