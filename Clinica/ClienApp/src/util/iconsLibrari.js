import { library } from "@fortawesome/fontawesome-svg-core";
import {
  fas,
  faBars,
  faUser,
  faAngleLeft,
  faAngleDown,
  faChartBar,
  faClose,
  faPlus,
  faListCheck,
  faLock,
  faArrowRightFromBracket,
} from "@fortawesome/free-solid-svg-icons";

export const icons = () =>
  library.add(
    fas,
    faAngleLeft,
    faAngleDown,
    faUser,
    faChartBar,
    faBars,
    faClose,
    faPlus,
    faListCheck,
    faLock,
    faArrowRightFromBracket,
  );
