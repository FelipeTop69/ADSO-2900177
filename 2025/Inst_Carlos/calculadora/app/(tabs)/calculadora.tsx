// app/(tabs)/calculadora.tsx
import { Picker } from '@react-native-picker/picker';
import { useState } from 'react';
import { Button, StyleSheet, Text, TextInput, View } from 'react-native';

export default function CalculadoraScreen() {
    const [a, setA] = useState('');
    const [b, setB] = useState('');
    const [op, setOp] = useState('suma');
    const [resultado, setResultado] = useState<number | undefined>(undefined);


    const calcular = () => {
        const na = parseFloat(a);
        const nb = parseFloat(b);
        if (isNaN(na) || isNaN(nb)) {
            setResultado(undefined);
            return;
        }

        const r = (() => {
            switch (op) {
                case 'suma': return na + nb;
                case 'resta': return na - nb;
                case 'mult': return na * nb;
                case 'div': return nb !== 0 ? na / nb : NaN;
                default: return NaN;
            }
        })();

        setResultado(r);
    };


    return (
        <View style={styles.container}>
            <Text>Primer número:</Text>
            <TextInput
                placeholder="Ingresa el primer número"
                style={styles.input}
                keyboardType="numeric"
                value={a}
                onChangeText={setA}
            />
            <Text>Segundo número:</Text>
            <TextInput
                placeholder="Ingresa el segundo número"
                style={styles.input}
                keyboardType="numeric"
                value={b}
                onChangeText={setB}
            />

            <Text>Operación:</Text>
            <Picker
                selectedValue={op}
                style={styles.picker}
                onValueChange={setOp}
            >
                <Picker.Item label="Suma" value="suma" />
                <Picker.Item label="Resta" value="resta" />
                <Picker.Item label="Multiplicación" value="mult" />
                <Picker.Item label="División" value="div" />
            </Picker>

            <Button title="Calcular" onPress={calcular} />

            {resultado !== undefined && (
                <Text style={styles.result}>
                    Resultado: {isNaN(resultado) ? 'Error: división por 0' : resultado}
                </Text>
            )}
        </View>
    );
}

const styles = StyleSheet.create({
    container: { flex: 1, padding: 20 },
    input: {
        borderWidth: 1, borderColor: '#ccc',
        borderRadius: 5, padding: 8, marginVertical: 5,
    },
    picker: { height: 50, width: '100%', marginVertical: 5 },
    result: { marginTop: 20, fontSize: 18, fontWeight: 'bold' },
});
