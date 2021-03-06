# DynamicsCrm-xrm-mock-Generator

(No longer maintained!)

[![Join the chat at https://gitter.im/yagasoft/DynamicsCrm-xrm-mock-Generator](https://badges.gitter.im/yagasoft/DynamicsCrm-xrm-mock-Generator.svg)](https://gitter.im/yagasoft/DynamicsCrm-xrm-mock-Generator?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

### Version: 1.3.2.3
---

An XrmToolBox plugin that can be used to generate the XRM form model for xrm-mock test framework.

## Prerequisites

### Offline

The following packages must be installed before using the generated model:

+ `@types/xrm`
+ `xrm-mock`

For convenience, run the following command:
```bash
npm i -D @types/xrm@9.0.9 xrm-mock@3.4.10
```

### Online

The following packages must be installed before enabling online communication:

+ `@types/jquery`
+ `@types/jsdom`
+ `@types/sinon`
+ `jquery`
+ `jsdom`
+ `node-dcrm-service`
+ `sinon`

For convenience, run the following command:
```bash
npm i -D @types/jquery@3.3.28 @types/jsdom@12.2.0 @types/sinon@7.0.2 @types/xrm@9.0.9 jquery@3.3.1 jsdom@13.1.0 node-dcrm-service@3.1.4 sinon@7.2.2 xrm-mock@3.4.10
```

## Usage

+ Load data
+ Choose an entity
+ Select forms
+ Generate model
+ Build the model before testing

```typescript
const builder = new XrmModel.ModelBuilder(new XrmModel.account());
builder.selectForm("Account");
builder.buildModel();
```

## Enable online communication
The model generated supports forwarding HTTP requests from `Xrm.WebApi` and jQuery to CRM. Otherwise, the function must be stubbed manually, or an error will be produced.

```typescript
const config = {<...>}
builder.enableOnlineWebApi(config)
   .then(() => Contact_OnLoad());
```

Configuration details can be found at [DynamicsCrm-NodeCrmService](https://www.npmjs.com/package/node-dcrm-service).

## Credit

+ camelCaseDave
  + xrm-mock
  + https://github.com/camelCaseDave/xrm-mock
		
## Changes

#### _v1.3.2.3 (2018-12-25)_
+ Fixed: tab and section names
#### _v1.3.2.1 (2018-12-24)_
+ Fixed: compile issues with generated code
#### _v1.3.1.2 (2018-09-07)_
+ Added: option to skip generate online communication code
+ Fixed: Early-bound conflict with other plugins
#### _v1.2.2.3 (2018-08-28)_
+ Added: boolean control support
+ Changed: plugin colours
#### _v1.2.1.6 (2018-08-27)_
+ Added: online communication option
+ Added: option to specify org URL for use with `getClientUrl`
...
#### _v1.0.3.2 (2018-08-17)_
+ Initial release

---
**Copyright &copy; by Ahmed el-Sawalhy ([Yagasoft](http://yagasoft.com))** -- _GPL v3 Licence_
