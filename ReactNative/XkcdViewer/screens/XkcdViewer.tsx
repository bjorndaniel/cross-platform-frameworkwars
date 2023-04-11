import React from 'react';
import {Box, FlatList, Spinner, Text} from 'native-base';
import {ApiService} from '../services/ApiService';
import {useInfiniteQuery} from 'react-query';
import {XkcdItem} from '../items/XkcdItem';
import {StyleSheet} from 'react-native';
import {DefaultStyles} from '../App';

export const XkcdViewer = () => {
  const {data, fetchNextPage, isFetchingNextPage} = useInfiniteQuery(
    'xkcd',
    ApiService.getComics,
    {
      getNextPageParam: pages => {
        if (pages && pages.length > 0) {
          return pages[pages.length - 1].num - 1;
        }
        return undefined;
      },
    },
  );
  return (
    <Box flex={1}>
      <FlatList
        data={data?.pages.map(page => page).flat()}
        keyExtractor={item => item.num.toString()}
        renderItem={({item}) => <XkcdItem {...item} />}
        onEndReached={() => fetchNextPage()}
      />
      {isFetchingNextPage && (
        <Box style={styles.spinner}>
          <Text style={styles.spinnertext}> Fetching more data...</Text>
          <Spinner />
        </Box>
      )}
    </Box>
  );
};
const styles = StyleSheet.create({
  spinner: {
    height: 80,
  },
  spinnertext: {
    ...DefaultStyles.textDefaults,
  },
});
