package at.resign;

import javafx.animation.Interpolator;
import javafx.animation.RotateTransition;
import javafx.animation.TranslateTransition;
import javafx.application.Platform;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import javafx.util.Duration;

import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.ResourceBundle;

public class XmasBackground implements Initializable {
    public ImageView snowflake;
    public Label time;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        RotateSnowflake();
        ClockThread();
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

    private void ClockThread() {
        final Thread thread = new Thread(() -> {
            SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
            while(true){
                try{
                    Thread.sleep(1000);
                } catch (InterruptedException e){
                    e.printStackTrace();
                }
                String currentTime = sdf.format(new Date().getTime());
                Platform.runLater(()->time.setText(currentTime));
            }
        });
        thread.setDaemon(true);
        thread.start();
    }
}
