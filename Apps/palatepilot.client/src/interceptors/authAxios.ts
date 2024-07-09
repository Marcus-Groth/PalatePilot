import localService from "@/services/localService";
import axios from "axios";

const authAxios = axios.create();

authAxios.interceptors.request.use(
  (config) => {
    config.baseURL = "https://localhost:7200/api";
    config.headers.Authorization = `Bearer ${localService.get("jwt")}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default authAxios;
