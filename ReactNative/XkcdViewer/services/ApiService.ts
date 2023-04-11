import IXkcdComic from '../data/IXkcdComic';

export class ApiService {
  public static async getComics({pageParam = 0}): Promise<IXkcdComic[]> {
    let currentComic = pageParam;
    let comics: IXkcdComic[] = [];
    for (let i = 0; i < 10; i++) {
      let response =
        currentComic === 0
          ? await fetch('https://xkcd.com/info.0.json')
          : await fetch(`https://xkcd.com/${currentComic}/info.0.json`);
      let comic = await response.json();
      comic.info = `${comic.year}-${comic.month.padStart(
        2,
        '0',
      )}-${comic.day.padStart(2, '0')} (${comic.num})`;
      comics.push(comic);
      currentComic = comic.num - 1;
    }
    return comics;
  }
}
