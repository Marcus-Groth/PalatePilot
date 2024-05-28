import authAxios from "@/interceptors/authAxios";

export default {
    
  async getAll(): Promise<any> {
    try {
      const url = '/Food'
      const response = await authAxios.get(url);
      console.log(response.data);
    }

    catch (error: any) {
      const response = error.response;
      console.error(response.data);
    }
  },
}
