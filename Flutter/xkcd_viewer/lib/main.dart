import 'package:flutter/material.dart';
import 'package:xkcd_viewer/screens/xkcd_feed.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        brightness: Brightness.dark,
        primarySwatch: Colors.blue,
      ),
      home: Scaffold(
        appBar: AppBar(
          title: const Text('xkcd viewer'),
        ),
        body: const Padding(
          padding: EdgeInsets.all(8.0),
          child: XkcdFeed(),
        ),
      ),
    );
  }
}
