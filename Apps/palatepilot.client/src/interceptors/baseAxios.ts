import axios from "axios";

const baseAxios = axios.create()

baseAxios.interceptors.request.use( config => {
    config.baseURL = 'https://localhost:7200/api'
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);

export default baseAxios;