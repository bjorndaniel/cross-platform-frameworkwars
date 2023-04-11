import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart';
import '../models/xkcd_comic.dart';
import '../widgets/xkcd_widget.dart';

class XkcdFeed extends StatefulWidget {
  const XkcdFeed({Key? key}) : super(key: key);

  @override
  _XkcdFeedState createState() => _XkcdFeedState();
}

class _XkcdFeedState extends State<XkcdFeed> {
  late bool _isLoading;
  late bool _isError;
  late List<XkcdComic> _comics;
  late int _currentComicNumber;
  final int _loadTrigger = 5;

  @override
  void initState() {
    super.initState();
    _isLoading = true;
    _isError = false;
    _comics = [];
    _currentComicNumber = 0;
    _loadComics();
  }

  @override
  Widget build(BuildContext context) {
    if (_isLoading) {
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_isError) {
      return const Center(
        child: Text('Error'),
      );
    }
    return PageView.builder(
      itemCount: _comics.length,
      scrollDirection: Axis.vertical,
      itemBuilder: (context, index) {
        if (index == _comics.length - _loadTrigger) {
          _loadComics();
        }
        return XkcdWidget(
          comic: _comics[index],
        );
      },
    );
  }

  Future<void> _loadComics() async {
    try {
      _isLoading = true;
      final response = _currentComicNumber == 0
          ? await get(Uri.parse('https://xkcd.com/info.0.json'))
          : await get(Uri.parse(
              'https://xkcd.com/${_currentComicNumber - 1}/info.0.json'));
      final jsonBody = json.decode(response.body);
      XkcdComic comic = XkcdComic.fromJson(jsonBody);
      _comics.add(comic);
      for (int i = 0; i < 10; i++) {
        if (comic.comicNumber > 1) {
          final response = await get(Uri.parse(
              'https://xkcd.com/${comic.comicNumber - 1}/info.0.json'));
          final jsonBody = json.decode(response.body);
          comic = XkcdComic.fromJson(jsonBody);
          _comics.add(comic);
        }
      }
      setState(() {
        _currentComicNumber = comic.comicNumber;
        _isLoading = false;
      });
    } catch (e) {
      setState(() {
        _isError = true;
      });
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }
}
