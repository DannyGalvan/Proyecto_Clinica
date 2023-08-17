import { useState } from "react";

export const useWidth = (initial) => {
  const [width, setWidth] = useState(false);

  const resScreenResize = () => {
    const witd = document.querySelector("body").clientWidth;
    witd > initial ? setWidth(false) : setWidth(true);
  };

  const addEventWidth = () => {
    resScreenResize();
    window.addEventListener("resize", resScreenResize);
  };

  const removeEventWidth = () => {
    window.removeEventListener("resize", resScreenResize);
  };

  return {
    addEventWidth,
    removeEventWidth,
    width,
  };
};
