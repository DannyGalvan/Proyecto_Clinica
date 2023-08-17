import { clinical } from "../axios/interceptors.js";

export const Login = (form) => {
  return clinical.post("/auth", form);
};
