import axios from "axios";

export const clinical = axios.create({
  baseURL: "/api",
});

export const authorization = clinical.interceptors.response.use(
  async (response) => {
    return response.data;
  },
  (error) => {
    const { response } = error;

    return response.data;
  },
);

export const setAuthorization = (token) => {
  if (token !== undefined || token !== null) {
    clinical.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  } else {
    clinical.defaults.headers.common["Authorization"] = token;
  }
};
