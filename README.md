# ds-lib-unece
With this package you can convert the codes in UNECE Recomendation 20 (unit of measures) in SI-symbols and back.

## Usage

``` csharp
string siCode = UnitOfMeasureUneceSIConverter.UneceToSI("MTR"); // returns "m"

string uneceCode = UnitOfMeasureUneceSIConverter.SIToUnece("m"); // returns "MTR"
```
