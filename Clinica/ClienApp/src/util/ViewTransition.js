export const transitionViewIfSupported = (updateCb) => {
  console.log("ejecutanda");
  if (document.startViewTransition) {
    document.startViewTransition(updateCb);
  } else {
    updateCb();
  }
};
