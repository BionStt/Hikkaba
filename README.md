Hikkaba
=====

Hikkaba is an imageboard written in ASP.NET Core and Entity Framework with minimal JavaScript usage.

Features
========

- [x] Multiple files per post
   * Audio
   * Video
   * Pictures
   * Documents
- [x] Thumbnail generation ([ImageSharp](https://github.com/JimBobSquarePants/ImageSharp) is still in early stages (alpha) so it contains some bugs)
- [x] BBCode markup support ([CodeKicker.BBCode-Mod](https://github.com/Pablissimo/CodeKicker.BBCode-Mod) by http//codekicker.de and Paul O'Neill)
   * b, i, u, s, pre, sub, sup, spoiler, quote BBCodes are availiable
   * >>postId - link to the post in current thread
- [x] SAGE support
- [x] URI detection
   * http://, https://, ftp:// links autodetection
- [x] Captcha ([DNTCaptcha.Core](https://github.com/VahidN/DNTCaptcha.Core))
- [x] Server-side paging (using [Sakura.AspNetCore.PagedList](https://github.com/sgjsakura/AspNetCore/))
- [x] Thread-local user hashes (can be enabled for each thread separately)
- [x] Search
- [x] Display a datetime in current user timezone (using [Moment.js](http://momentjs.com/))
- [x] Support for multiple file storage engines (using [20|20 Storage](https://github.com/2020IP/TwentyTwenty.Storage))
   * Local File System Storage (enabled by default)
   * Azure Blob Storage
   * Amazon S3
   * Google Cloud Storage
- [ ] Administration panel
- [ ] Moderator powers customization
- [x] Moderation functions
- [x] Ban system - by IP or IP range
- [ ] Max file size limitation
- [ ] Max total files size per post limitation
- [ ] Max attachments count limitation
- [ ] Identity lockout
- [ ] Max threads limit per category
- [ ] Archivation & deletion of old threads
- [ ] Media gallery
- [ ] API
- [ ] Embedding of youtube, vimeo, coub, twitter, instagram objects
- [ ] Detection of attachment duplicates per thread
- [ ] Image files optimization
- [ ] Display thread-local user hashes as google docs-like colored animals
- [ ] Primary key types - GUID or BIGINT

Screenshots
========

## Home page
![Home page](http://i.imgur.com/VSqxCqE.png)

## Reply form
![Reply form](http://i.imgur.com/aVO3paD.png)

## Thread
![Thread](http://i.imgur.com/OLJ8YS6.png)

## Search
![Search](http://i.imgur.com/wkp4WoR.png)