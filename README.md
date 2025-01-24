# ds-lib-unece
With this package you can convert the codes in UNECE Recomendation 20 (unit of measures) in SI-symbols and back.

## Usage

``` csharp
string siCode = UnitOfMeasureTranslator.UNECEtoSI("MTR"); // returns "m"

string uneceCode = UnitOfMeasureTranslator.SItoUNECE("m"); // returns "MTR"

bool found = UnitOfMeasureTranslator.TrySItoUNECE("m", out string code); // returns true and code = "MTR"

bool found = UnitOfMeasureTranslator.TryUNECEtoSI("MTR", out string code); // returns true and code = "m"

bool found = UnitOfMeasureTranslator.TryUNECEtoSI("BLAH", out string code); // returns false and code = "BLAH"

bool found = UnitOfMeasureTranslator.TryUNECEtoSI("BLAH", out string code, "fallback); // returns false and code = "fallback"

Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
string code = UnitOfMeasureTranslator.UNECEtoSI("LS"); // returns "Pauschal"

Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
string code = UnitOfMeasureTranslator.UNECEtoSI("LS"); // returns "lump sum"


```
