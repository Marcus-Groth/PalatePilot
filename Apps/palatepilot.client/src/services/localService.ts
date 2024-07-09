export default {
  set(key: string, data: string): void {
    if (data !== undefined) {
      localStorage.setItem(key, JSON.stringify(data));
    }
  },

  get(key: string): string | null {
    const item = localStorage.getItem(key);
    return item ? JSON.parse(item) : null;
  },

  delete(key: string): void {
    localStorage.removeItem(key);
  },
};
