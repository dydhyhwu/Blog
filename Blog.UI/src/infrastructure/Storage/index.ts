export interface Storage {
  get<T = any>(key: string): T | null;
  set<T = any>(key: string, value: T): void;
  clear(key: string): void;
  clearAll(): void;
}

export default class LocalStorage implements Storage {
  private static instance: Storage = new LocalStorage();

  static get Instance() {
    return LocalStorage.instance;
  }

  get<T = any>(key: string): T | null {
    const value = localStorage.getItem(key);
    if (value === null) {
      return null;
    }
    return JSON.parse(value) as T;
  }

  set<T = any>(key: string, value: T): void {
    const valueStr = JSON.stringify(value);
    localStorage.setItem(key, valueStr);
  }

  clear(key: string): void {
    localStorage.removeItem(key);
  }

  clearAll(): void {
    localStorage.clear();
  }
}
