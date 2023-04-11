class XkcdComic {
  final String title;
  final String altText;
  final String imgUrl;
  final int comicNumber;
  final int year;
  final int month;
  final int day;

  XkcdComic({
    required this.title,
    required this.altText,
    required this.imgUrl,
    required this.comicNumber,
    required this.year,
    required this.month,
    required this.day,
  });

  factory XkcdComic.fromJson(Map<String, dynamic> json) {
    return XkcdComic(
      title: json['title'],
      altText: json['alt'],
      imgUrl: json['img'],
      comicNumber: json['num'],
      year: int.parse(json['year']),
      month: int.parse(json['month']),
      day: int.parse(json['day']),
    );
  }
}
