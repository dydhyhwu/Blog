import { HttpRequestFilter } from '.';
import { AxiosRequestConfig } from 'axios';
import LocalStorage from '@/infrastructure/Storage';
import { Token } from '@/domain/getters';

export default class AxiosHttpRequestFilter implements HttpRequestFilter {
  process(config: AxiosRequestConfig): AxiosRequestConfig {
    const token = LocalStorage.Instance.get(Token);
    config.headers = {};
    if (token) {
      config.headers[Token] = token;
    }
    return config;
  }
}
