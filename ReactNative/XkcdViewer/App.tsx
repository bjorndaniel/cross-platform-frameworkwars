import {Box, NativeBaseProvider} from 'native-base';
import React from 'react';
import {StyleSheet, Text} from 'react-native';
import {QueryClient, QueryClientProvider} from 'react-query';
import {XkcdViewer} from './screens/XkcdViewer';

const queryClient = new QueryClient();

function App(): JSX.Element {
  return (
    <NativeBaseProvider>
      <QueryClientProvider client={queryClient}>
        <Box flex={1} style={DefaultStyles.container} safeAreaTop>
          <Text style={DefaultStyles.header}>Xkcd viewer</Text>
          <XkcdViewer />
        </Box>
      </QueryClientProvider>
    </NativeBaseProvider>
  );
}

export const DefaultStyles = StyleSheet.create({
  container: {
    backgroundColor: '#000',
    padding: 10,
  },
  textDefaults: {
    color: '#fff',
    verticalAlign: 'middle',
    textAlign: 'center',
  },
  header: {
    color: '#fff',
    verticalAlign: 'middle',
    textAlign: 'center',
    fontSize: 24,
    fontWeight: 'bold',
  },
});

export default App;
