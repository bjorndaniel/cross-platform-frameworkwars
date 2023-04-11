import 'package:flutter/material.dart';

import '../models/xkcd_comic.dart';

class XkcdWidget extends StatelessWidget {
  final XkcdComic comic;
  const XkcdWidget({
    Key? key,
    required this.comic,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final fontSize = MediaQuery.of(context).size.width * 0.5;
    return Container(
      height: double.infinity,
      width: double.infinity,
      decoration: const BoxDecoration(
        borderRadius: BorderRadius.all(Radius.circular(15)),
        gradient: LinearGradient(
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
          colors: [
            Colors.black,
            Color(0xFF3E3E3E),
          ],
        ),
      ),
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            Text(
              comic.title,
              textAlign: TextAlign.center,
              style: const TextStyle(
                fontSize: 32,
                overflow: TextOverflow.ellipsis,
                fontWeight: FontWeight.bold,
              ),
            ),
            Text(
              '${comic.year}-${comic.month.toString().padLeft(2, '0')}-${comic.day.toString().padLeft(2, '0')}(${comic.comicNumber})',
              style: const TextStyle(
                fontSize: 12,
              ),
            ),
            const SizedBox(
              height: 10.0,
            ),
            Image.network(
              comic.imgUrl,
              height: MediaQuery.of(context).size.height * 0.6,
              fit: BoxFit.contain,
            ),
            const SizedBox(
              height: 10.0,
            ),
            Text(
              comic.altText,
            )
          ],
        ),
      ),
    );
  }
}
