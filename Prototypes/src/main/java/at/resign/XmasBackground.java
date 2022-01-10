package at.resign;

import javafx.animation.Interpolator;
import javafx.animation.RotateTransition;
import javafx.animation.TranslateTransition;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import javafx.util.Duration;

import java.net.URL;
import java.util.ResourceBundle;

public class XmasBackground implements Initializable {
    public ImageView snowflake;
    public Label time;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        PrototypeController pc = new PrototypeController();

        pc.startClockThread(time);
        RotateSnowflake();
    }

    private void RotateSnowflake() {
        TranslateTransition tt = new TranslateTransition();
        tt.setNode(snowflake);
        tt.setDuration(Duration.millis(2000));
        tt.setCycleCount(TranslateTransition.INDEFINITE);
        tt.setByY(50);
        tt.setAutoReverse(true);
        tt.play();

        RotateTransition rt = new RotateTransition();
        rt.setNode(snowflake);
        rt.setDuration(Duration.millis(20000));
        rt.setCycleCount(TranslateTransition.INDEFINITE);
        rt.setInterpolator(Interpolator.LINEAR);
        rt.setByAngle(360);


        tt.play();
        rt.play();
    }
}
