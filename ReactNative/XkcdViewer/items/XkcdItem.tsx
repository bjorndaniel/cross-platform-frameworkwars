import React, {FC} from 'react';
import IXkcdComic from '../data/IXkcdComic';
import {Box, Text, Image} from 'native-base';
import {StyleSheet} from 'react-native';
import {DefaultStyles} from '../App';

export const XkcdItem: FC<IXkcdComic> = comic => {
  return (
    <Box flex={1} style={styles.container}>
      <Text style={styles.title}>{comic.title}</Text>
      <Text style={styles.info}>{comic.info}</Text>
      <Image style={styles.img} source={{uri: comic.img}} alt={comic.alt} />
      <Text style={styles.alt}>{comic.alt}</Text>
    </Box>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 10,
  },
  title: {
    ...DefaultStyles.textDefaults,
    fontSize: 18,
    fontWeight: 'bold',
  },
  info: {
    ...DefaultStyles.textDefaults,
    fontSize: 12,
  },
  img: {
    width: '100%',
    height: 300,
    resizeMode: 'contain',
  },
  alt: {
    ...DefaultStyles.textDefaults,
    fontSize: 16,
  },
});
