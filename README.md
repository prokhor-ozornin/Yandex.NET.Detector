**Yandex.Detector** is a .NET library for [Yandex.Detector web service](http://api.yandex.ru/detector) that supplies information about capabilities of mobile devices based on provided HTTP headers.

**NuGet package** : https://www.nuget.org/packages/Yandex.Detector

***

**Support**

This project needs your support for further developments ! Please consider donating.

- _Yandex.Money_ : 41001577953208

- _WebMoney (WMR)_ : R399275865890

[![Image](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=APHM8MU9N76V8 "Donate")

***

**Usage examples:**

`IMobileDevice device = Yandex.Detector.Detect(new Dictionary<string, object> { { "User-agent", "Alcatel-CTH3/1.0 UP.Br" } });`

`IMobileDevice device = Yandex.Detector.Detect(request => request.UserAgent("Alcatel-CTH3/1.0 UP.Br").Profile("http://www-ccpp-mpd.alcatel.com/files/ALCATEL-CTH3_MMS10_1.0.rdf"));`