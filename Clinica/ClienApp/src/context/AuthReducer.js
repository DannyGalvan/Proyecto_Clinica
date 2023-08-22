// generates the state
import { authInitialState } from "./AuthContext.jsx";
import { setAuthorization } from "../axios/interceptors.js";

export const AuthReducer = (state, action) => {
  let newState;
  switch (action.type) {
    case "signIn":
      newState = {
        ...state,
        isLoggedIn: true,
        ...action.payload,
      };
      setAuthorization(action.payload.token);
      window.localStorage.setItem("@auth", JSON.stringify(newState));
      return newState;
    case "logout":
      window.localStorage.clear();
      return authInitialState;
    default:
      return state;
  }
};
