import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import Highscore from "./components/Highscore";
import Game from "./components/Game";
import Statistics from "./components/Statistics"
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/highscore',
    element: <Highscore />
  },
  {
    path: '/game',
    element: <Game />
  },
  {
      path: '/statistics',
     element: <Statistics/>
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
