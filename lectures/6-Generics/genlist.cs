public class genlist<T>{
    public T[] data;
    public genlist(){
        data = new T[0];
    }
    public void push(T item){
        int n = data.Length;
        T[] newData = new T[n+1];
        for(int i = 0; i<n; i++){
            newData[i] = data[i];
        }
        data = newData; //remember that arrays are references, so the reference for data is moved to newData (the garbage collecter will delete the old data array)
        data[n] = item;
    }


}