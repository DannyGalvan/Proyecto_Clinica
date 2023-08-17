export const loadImages = (name) => {
  return new URL(`${name}`, import.meta.url).href;
};
