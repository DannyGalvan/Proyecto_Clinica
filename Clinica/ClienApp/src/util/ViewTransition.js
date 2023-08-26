export const transitionViewIfSupported = (updateCb) => {
  if (document.startViewTransition) {
    document.startViewTransition(updateCb);
  } else {
    updateCb();
  }
};
