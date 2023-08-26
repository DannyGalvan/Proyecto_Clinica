import { transitionViewIfSupported } from "../../util/ViewTransition.js";
import { useNavigate } from "react-router-dom";

export const AnimatedLink = ({ className, to, children }) => {
  const navigate = useNavigate();
  return (
    <a
      href={to}
      className={className}
      onClick={(ev) => {
        ev.preventDefault();
        transitionViewIfSupported(() => {
          navigate(to);
        });
      }}
    >
      {children}
    </a>
  );
};
