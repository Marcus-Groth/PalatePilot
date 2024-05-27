export default {
    set(key: string, data: string): void {
      if (data !== undefined) {
        localStorage.setItem(key, JSON.stringify(data));
      }
    },
  };