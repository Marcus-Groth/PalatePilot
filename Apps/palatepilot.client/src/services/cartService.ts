import authAxios from "@/interceptors/authAxios";

export default {
    
  async addItemToCart(foodId: number) {
    try {
      const response = await authAxios.post(`/Cart?FoodId=${foodId}`);
      console.log(response.data)
    } 
    
    catch (error: any) {
      const response = error.response;
      console.error(response.data);
    }
  },
}
